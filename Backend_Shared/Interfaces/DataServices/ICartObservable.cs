using System;
using Backend_Shared.Models;
using DynamicData;

namespace Backend_Shared.Interfaces.DataServices
{
    public interface ICartObservable: IObservable<ChangeSet<CartModel,string>>
    {
        
    }
}