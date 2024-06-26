﻿using BankingServiceAPI.Context;
using BankingServiceAPI.Models;
using BankingServiceAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace XUnitTests.BankingServiceAPI.Repositories;

public class WithdrawRepositoryTests
{
    private readonly WithdrawRepository  _withdrawRepository;
    private readonly AppDbContext _context;

    public WithdrawRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _withdrawRepository = new WithdrawRepository(_context);
    }

    [Fact]
    public async Task GetByAccountNumberAsync_Should_Return_BankAccount_By_AccountNumber()
    {
        // Arrange
        var user = new User();
        user.SetId("123");
        user.SetName("John");
        user.SetLastName("John");
        user.SetEmail("john.doe@example.com");
        user.SetPhoneNumber("123456789");
        user.SetCpf("123.456.789-00");
        user.SetRole("Admin");

        var bankAccount = new BankAccount();
        bankAccount.SetId(1);
        bankAccount.SetAccountNumber(123456);
        bankAccount.SetAgency(1234);
        bankAccount.SetBalance(100);
        bankAccount.SetAccountType(AccountType.Savings);
        bankAccount.SetUser(user);

        await _context.BankAccounts.AddAsync(bankAccount);
        await _context.SaveChangesAsync();

        // Act
        var result = await _withdrawRepository.GetByAccountNumberAsync(123456);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(123456, result.AccountNumber);
    }

    [Fact]
    public async Task GetByAccountNumberAsync_Should_Return_Null_If_Not_Found()
    {
        // Act
        var result = await _withdrawRepository.GetByAccountNumberAsync(999999);

        // Assert
        Assert.Null(result);
    }
}