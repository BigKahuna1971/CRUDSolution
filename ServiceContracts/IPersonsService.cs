﻿using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating person entity
    /// </summary>
    public interface IPersonsService
    {
        /// <summary>
        /// Adds a new person into the list of persons
        /// </summary>
        /// <param name="personAddRequest">Person to add</param>
        /// <returns>Returns the same person details, alongwith newly generated PersonID</returns>
        PersonResponse AddPerson(PersonAddRequest?
            personAddRequest);

        /// <summary>
        /// returns all persons
        /// </summary>
        /// <returns>Returns a list of objects of PersonResponse type</returns>

        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Returns the person object based on the given person id
        /// </summary>
        /// <param name="personID">Person id to search</param>
        /// <returns>Returns matching person object</returns>

        PersonResponse? GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Returns all person objects that matches with the given search field andsearch string
        /// </summary>
        /// <param name="searchBy">Search field to search</param>
        /// <param name="searchString">Search stringto search</param>
        /// <returns>Returns all matching persons based on the given search field and search string</returns>

        List<PersonResponse> GetFilteredPersons(string searchBy,
            string? searchString);

        /// <summary>
        /// Returns sorted list of persons
        /// </summary>
        /// <param name="allPersons">Represents list of persons to sort</param>
        /// <param name="sortBy">Name of the property (Key),  based on which the person should be sorted</param>
        /// <param name="sortOrder">ASC or DESC</param>
        /// <returns>Returns sorted persons as PersonResponse list</returns>

        List<PersonResponse> GetSortedPersons(List<PersonResponse>
            allPersons, string sortBy, SortOrderOptions sortOrder);


        /// <summary>
        /// Updates the specified  person details based on the given 
        /// person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person details to update,
        /// including person ID</param>
        /// <returns>Returns the person response object after 
        /// update</returns>

        PersonResponse UpdatePerson(PersonUpdateRequest?
            personUpdateRequest);

        /// <summary>
        /// Deletes a person based on the given person id
        /// </summary>
        /// <param name="personID">PersonID to delete</param>
        /// <returns>Returns true, if the deletion is successful; otherwise false</returns>

        bool DeletePerson(Guid personID);
    }
}
