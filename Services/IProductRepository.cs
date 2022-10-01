using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on Products 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Adds the passed record object to the database
        /// </summary>
        /// <param name="product">record to be added</param>
        void AddRecord(Product product);

        /// <summary>
        /// Retrieves the record for the passed ID
        /// </summary>
        /// <param name="ID">ID of the record to be retrieved</param>
        /// <returns>the record that matches passed ID or null if the ID is not found in database</returns>
        Product GetRecord(int? ID);

        /// <summary>
        /// updates the record that has the passed ID
        /// </summary>
        /// <param name="product">the record with its fields updated</param>
        void UpdateRecord(Product product);

        /// <summary>
        /// deletes the record that has the passed ID
        /// </summary>
        /// <param name="ID">the ID of the record to be deleted</param>
        void DeleteRecord(int? ID);

        /// <summary>
        /// to get the highest ID value in the database
        /// </summary>
        /// <returns>highest ID value</returns>
        int MaxID();

        /// <summary>
        /// to get all Product records from the database
        /// </summary>
        /// <returns>a list of all products in the database</returns>
        List<Product> GetAllProducts();
    }
}
