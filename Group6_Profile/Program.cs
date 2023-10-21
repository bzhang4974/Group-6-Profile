using System;
using System.Collections.Generic;
using System.Linq;

public class ProfileModule
{
    // User profile data structure
    public class UserProfile
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public Address Address { get; set; }
        public AccountType Type { get; set; }
    }

    // Credit card data structure
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        // Add other properties as needed
    }

    // Address data structure
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        // Add other address-related properties
    }

    // Account types
    public enum AccountType
    {
        Customer,
        Seller,
        Admin
    }

    private List<UserProfile> userProfiles;

    public ProfileModule()
    {
        userProfiles = new List<UserProfile>();
    }

    // User login
    public UserProfile Login(string username, string password)
    {
        UserProfile user = userProfiles.Find(u => u.Username == username && u.Password == password);
        return user;
    }

    // Account recovery
    public UserProfile RecoverAccount(string emailOrPhoneNumber)
    {
        UserProfile user = userProfiles.Find(u => u.Email == emailOrPhoneNumber || u.PhoneNumber == emailOrPhoneNumber);
        return user;
    }

    // Register a new account
    public bool RegisterNewAccount(string username, string password, string email, string phoneNumber, AccountType type)
    {
        if (userProfiles.Any(u => u.Username == username))
        {
            return false; // Username already exists
        }

        var newUser = new UserProfile
        {
            Username = username,
            Password = password,
            Email = email,
            PhoneNumber = phoneNumber,
            CreditCards = new List<CreditCard>(),
            Address = new Address(),
            Type = type
        };

        userProfiles.Add(newUser);
        return true; // Account registration successful
    }

    // Add credit card to the user's profile
    public void AddCreditCard(UserProfile user, CreditCard creditCard)
    {
        user.CreditCards.Add(creditCard);
    }

    // Update user address
    public void UpdateAddress(UserProfile user, Address address)
    {
        user.Address = address;
    }

/*
    // Placeholder methods for integration with other modules
    public void UpdateShoppingCart(ShoppingCartModule shoppingCart, UserProfile user, List<Product> productsToAdd, List<int> productIdsToRemove)
    {
        // Implement integration logic with the shopping cart module
        shoppingCart.AddProductsToCart(user, productsToAdd);
        shoppingCart.RemoveProductsFromCart(user, productIdsToRemove);
    }

    public Product GetProductInformation(ProductModule productModule, int productId)
    {
        // Implement integration logic with the product module
        return productModule.GetProductById(productId);
    } */
}
