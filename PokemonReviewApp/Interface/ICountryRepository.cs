﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Country> GetOwnersFromACountry(int countryId);
        bool CountryExists(int id);
    }
}