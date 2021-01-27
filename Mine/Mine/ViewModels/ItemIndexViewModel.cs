using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mine.Models;
using Mine.Views;

namespace Mine.ViewModels
{
    public class ItemIndexViewModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> DataSet { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemIndexViewModel()
        {
            Title = "Items";
            DataSet = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemCreatePage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                DataSet.Add(newItem);
                await DataStore.CreateAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemUpdatePage, ItemModel>(this, "UpdateItem", async (obj, item) =>
            {
                var data = item as ItemModel;

                await UpdateAsync(data);
            });

            MessagingCenter.Subscribe<ItemDeletePage, ItemModel>(this, "DeleteItem", async (obj, item) =>
            {
                var data = item as ItemModel;

                await DeleteAsync(data);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DataSet.Clear();
                var items = await DataStore.IndexAsync(true);
                foreach (var item in items)
                {
                    DataSet.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /* <summary>
         * Read an Item from the DataStore
         * </summary>
         * <param name="id">ID of the Record</param>
         * <returns>The Record from ReactAsync</returns>
         */ 
        public async Task<ItemModel> ReadAsync(string id)
        {
            var result = await DataStore.ReadAsync(id);

            return result;
        }

        /* <summary>
         * Update an Item from the DataStore
         * </summary>
         * <param name="data">The Record to Update</param>
         * <returns>True if updated</returns>
         */
        public async Task<bool> UpdateAsync(ItemModel data)
        {
            // Check if the record exists, id it does not, then null is returned
            var record = await ReadAsync(data.Id);
            if (record == null)
            {
                return false;
            }

            // Call to remove it from the DataStore
            var result = await DataStore.UpdateAsync(data);

            var canExecute = LoadItemsCommand.CanExecute(null);
            LoadItemsCommand.Execute(null);

            return result;
        }

        /* <summary>
         * Delete an Item from the DataStore
         * </summary>
         * <param name="data">The Record to Delete</param>
         * <returns>True if deleted</returns>
         */
        public async Task<bool> DeleteAsync(ItemModel data)
        {
            // Check if the record exists, id it does not, then null is returned
            var record = await ReadAsync(data.Id);
            if (record == null)
            {
                return false;
            }

            // Remove from the local data set cache
            DataSet.Remove(data);

            // Call to remove it from the DataStore
            var result = await DataStore.DeleteAsync(data.Id);

            return result;
        }
    }
}