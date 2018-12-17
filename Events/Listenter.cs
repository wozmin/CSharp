using System.Collections.Generic;

public class Listenter{
    
    private List<ListEntity> _collectionChanges;
    public List<ListEntity> CollectionChanges{
        get=> _collectionChanges ?? (_collectionChanges = new List<ListEntity>());
        set => _collectionChanges = value;
    }

    public void OnCollectionChanged(object source, MagazineListHandlerEventArgs args){
        CollectionChanges.Add(
            new ListEntity(
                args.CollectionName,
                args.ChangesType,
                args.ElementIndex
            )
        );
    }

   public override string ToString(){
       string info = "";
       foreach(var collectionChange in CollectionChanges){
           info+= $"Collection name: {collectionChange.CollectionName}\n ChangesType: {collectionChange.ChangesType}\n ElementIndex: {collectionChange.ElementIndex}\n\n";
       }
       return info;
    }
}