public class ListEntity {
    public string CollectionName{get;set;}
    public string ChangesType {get;set;}
    public int ElementIndex {get;set;}

    public ListEntity(string collectionName,string changesType,int elementIndex)
    {
        CollectionName = collectionName;
        ChangesType = changesType;
        ElementIndex = elementIndex;
    }

    public override string ToString(){
       return $"Collection name: {CollectionName}\n ChangesType: {ChangesType}\n ElementIndex: {ElementIndex}";
    }
}