using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        
        create type operation_type as enum ('withdrawal', 'replenishment');
        
        
        create table users
        (
            user_id BIGSERIAL PRIMARY KEY,
            user_name text not null,
            pincode text not null,
            balance decimal not null default 0.0
        );

        
        create table operation_history
        (
            operation_id BIGSERIAL PRIMARY KEY,
            user_id bigint not null references users(user_id) on delete cascade on update cascade,
            operation_type operation_type not null,
            operation_amount decimal not null,
            operation_result text not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table operation_history;
        drop table users;

        drop type operation_type;
        """;
}