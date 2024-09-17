using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Interfaces;
using UberSystem.Domain.Interfaces.Services;
 
namespace UberSystem.Service
{
	public class CabService: ICabService
	{
    	private readonly IUnitOfWork _unitOfWork;
    	public CabService(IUnitOfWork unitOfWork)
    	{
        	_unitOfWork = unitOfWork;
    	}
 
    	public async Task<IList<Cab>> GetAll()
    	{
        	return await _unitOfWork.Repository<Cab>().GetAllAsync();
    	}
 
    	public async Task<Cab> GetOne(int cabId)
    	{
        	return await _unitOfWork.Repository<Cab>().FindAsync(cabId);
    	}
 
    	public async Task Update(Cab cabInput)
    	{
        	try
        	{
            	await _unitOfWork.BeginTransaction();
 
            	var cabRepos = _unitOfWork.Repository<Cab>();
            	var cab = await cabRepos.FindAsync(cabInput.Id);
            	if (cab == null)
                	throw new KeyNotFoundException();
 
            	cab.RegNo = cabInput.RegNo;
 
          	  await _unitOfWork.CommitTransaction();
        	}
        	catch (Exception e)
        	{
            	await _unitOfWork.RollbackTransaction();
            	throw;
        	}
    	}
 
    	public async Task Add(Cab cabInput)
    	{
        	try
        	{
            	await _unitOfWork.BeginTransaction();
 
            	var cabRepos = _unitOfWork.Repository<Cab>();
            	await cabRepos.InsertAsync(cabInput);
 
            	await _unitOfWork.CommitTransaction();
        	}
        	catch (Exception e)
        	{
            	await _unitOfWork.RollbackTransaction();
            	throw;
        	}
    	}
 
    	public async Task Delete(int cabId)
    	{
            try
        	{
            	await _unitOfWork.BeginTransaction();
 
            	var cabRepos = _unitOfWork.Repository<Cab>();
            	var cab = await cabRepos.FindAsync(cabId);
            	if (cab == null)
         	       throw new KeyNotFoundException();
 
            	await cabRepos.DeleteAsync(cab);
 
            	await _unitOfWork.CommitTransaction();
        	}
        	catch (Exception e)
        	{
            	await _unitOfWork.RollbackTransaction();
            	throw;
        	}
    	}
	}
}