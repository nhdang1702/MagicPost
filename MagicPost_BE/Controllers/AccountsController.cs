﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagicPost_BE.Data;
using MagicPost_BE.Models;
using AutoMapper;
using MagicPost_BE.Interfaces;
using MagicPost_BE.DTO;

namespace MagicPost_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountsController(DataContext context, IAccountRepository accountRepository, IMapper mapper )
        {
            _context = context;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType( 200, Type = typeof(IEnumerable<Account> ))]
        public IActionResult GetAllAccounts()
        {
            var accounts = _mapper.Map<List<AccountDTO>>(_accountRepository.GetAllAccounts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accounts);
        }

        // GET: api/Accounts/5
        // Get Account by AccountID
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            var accounts = _mapper.Map<List<AccountDTO>>(_accountRepository.GetAccountById(id));
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(accounts);
        }

        //Get All Account by Office
        [Area("CEO")]
        [HttpGet("{officeId}")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccountByOffice(int officeId)
        {
            var accounts = _mapper.Map<List<AccountDTO>>(_accountRepository.GetAccountsByOffice(officeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(accounts);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
          if (_context.Accounts == null)
          {
              return Problem("Entity set 'DataContext.Accounts'  is null.");
          }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
