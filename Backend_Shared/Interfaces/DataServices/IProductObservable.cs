using System;
using Backend_Shared.Models;
using DynamicData;

namespace Backend_Shared.Interfaces.DataServices
{
    public interface IProductObservable: IObservable<ChangeSet<ProductModel,string>>
    {
        
    }
}