using DominoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.Data
{
    public class SettingsDatabaseController
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        public SettingsDatabaseController()
        {
            InitializeAsync().SafeFireandForget(false);
        }
        async Task InitializeAsync()
        {
            if (!initialized && !Database.TableMappings.Any(m => m.MappedType.Name == typeof(BasicSettings).Name))
            {
                await Database.CreateTablesAsync(CreateFlags.None, typeof(BasicSettings)).ConfigureAwait(false);
                initialized = true;
                await Database.InsertAsync(new BasicSettings());
            }
        }
        public async Task<BasicSettings> GetBasicSettingsAsync() => await Database.Table<BasicSettings>().FirstOrDefaultAsync();
        public async Task<int> SaveBasicSettingsAsync(BasicSettings basicSettings)
        {
            if (basicSettings.Id != 0)
            {
                await Database.UpdateAsync(basicSettings);
                return basicSettings.Id;
            }
            else
            {
                return await Database.InsertAsync(basicSettings);
            }
        }
    }
}
