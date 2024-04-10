using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace ATM.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type transaction_type as enum
        (
            'replenishment',
            'withdrawal'
        );

        create table accounts
        (
            account_number bigint not null primary key,
            account_pin integer not null,
            account_balance bigint not null
        );

        create table admins
        (
            admin_id bigint primary key generated always as identity,
            admin_password text
        );

        create table transactions
        (
            transaction_id bigint primary key generated always as identity,
            account_number bigint not null references accounts(account_number),
            transaction_type transaction_type not null,
            transaction_amount bigint not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table account;
        drop table admins;
        drop table transactions;

        drop type transaction_type;
        """;
}