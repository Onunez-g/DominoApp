using DominoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.Data
{
    public class MatchDatabaseController
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        public MatchDatabaseController()
        {
            InitializeAsync().SafeFireandForget(false);
        }
        async Task InitializeAsync()
        {
            if(!initialized && !Database.TableMappings.Any(m => m.MappedType.Name == typeof(MatchRound).Name))
            {
                await Database.CreateTablesAsync(CreateFlags.AutoIncPK, typeof(MatchRound)).ConfigureAwait(false);
                initialized = true;
            }
        }
        public async Task<IEnumerable<MatchRound>> GetMatchRoundsAsync() => await Database.Table<MatchRound>().ToListAsync();
        public async Task<int> SaveMatchRound(MatchRound matchRound)
        {
            if(matchRound.Id != 0)
            {
                await Database.UpdateAsync(matchRound);
                return matchRound.Id;
            }
            else
            {
                return await Database.InsertAsync(matchRound);
            }
        }
        public async Task<int> DeleteMatchRound(int id) => await Database.DeleteAsync<MatchRound>(id);
    }
}
