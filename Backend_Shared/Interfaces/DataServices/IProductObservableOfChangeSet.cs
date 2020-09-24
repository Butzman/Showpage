using System;
using Backend_Shared.Models;
using DynamicData;

namespace Backend_Shared.Interfaces.DataServices
{
    public interface IProductObservableOfChangeSet: IObservable<ChangeSet<ProductModel,string>>
    {
        
    }
}