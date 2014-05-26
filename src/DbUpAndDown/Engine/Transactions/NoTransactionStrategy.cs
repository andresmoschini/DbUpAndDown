using System;
using System.Collections.Generic;
using System.Data;
using DbUpAndDown.Engine.Output;

namespace DbUpAndDown.Engine.Transactions
{
    class NoTransactionStrategy : ITransactionStrategy
    {
        private IDbConnection connection;

        public void Execute(Action<Func<IDbCommand>> action)
        {
            action(()=>connection.CreateCommand());
        }

        public T Execute<T>(Func<Func<IDbCommand>, T> actionWithResult)
        {
            return actionWithResult(() => connection.CreateCommand());
        }

        public void Initialise(IDbConnection dbConnection, IUpgradeLog upgradeLog, List<SqlScript> executedScripts)
        {
            connection = dbConnection;            
        }

        public void Dispose() { }
    }
}