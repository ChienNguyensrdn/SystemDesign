using System.Collections.Generic;
using System.Threading.Tasks;
using UberSystem.Domain.Entities;
 
namespace UberSystem.Domain.Interfaces.Services
{
	public interface ICabService
	{
    	/// <summary>
    	/// Get all items of Work table
    	/// </summary>
    	/// <returns></returns>
    	Task<IList<Cab>> GetAll();
    	Task<Cab> GetOne(int cabId);
    	Task Update(Cab cab);
    	Task Add(Cab cab);
    	Task Delete(int cabId);
	}
}