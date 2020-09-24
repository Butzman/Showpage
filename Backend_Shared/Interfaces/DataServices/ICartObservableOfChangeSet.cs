using System;
using Backend_Shared.Models;
using DynamicData;

namespace Backend_Shared.Interfaces.DataServices
{
    public interface ICartObservableOfChangeSet: IObservable<ChangeSet<CartModel,string>>
    {
        
    }
}