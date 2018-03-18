using System;
namespace MacArchitecture.Utils {
    public class NativeArrays {
        public NativeArrays() {
        }

        //foreach (var item in NSArray.FromArray<Type>(array)) { 
        //    //code
        //}

        //NSMutableArray<ClassName> array = new NSMutableArray<ClassName>();  
        //foreach (var item in array) { 
        //}


        //option on for
        //for (nuint i = 0; i<_issuesArray.Count; ++i) {
        //var issue = _issuesArray.GetItem<ClassName>(i);
        //if (item.ErrorInfo.Error == issue.ErrorInfo.Error) {
        //    RemoveItem((nint) i);
        //    break;
        //}
        //}

        //sorting
        //array.SortDescriptors = new NSSortDescriptor[] {
        //new NSSortDescriptor("class_property1", false), 
        //new NSSortDescriptor("class_property2", true) };


        //native binding to array 
        //[Export("issueItemArray")]
        //public NSArray IssuesArray => _issuesArrayMainNode;
        //[Export("addObject:")]
        //public void AddItem(IssueItem item) {
        //    CallWillChangeInMainArray();
        //    _issuesArrayMainNode.Add(item);
        //    CallDidChangeInMainArray();
        //}
        //[Export("insertObject:inIssueItemArrayAtIndex:")] //insertObject:in{class_name}ArrayAtIndex: - Where {class_name} is the name of your class.
        //public void InsertItem(IssueItem item, nint index) {
        //    CallWillChangeInMainArray();
        //    _issuesArrayMainNode.Insert(item, index);
        //    CallDidChangeInMainArray();
        //}
        //[Export("removeObjectFromIssueItemArrayAtIndex:")] //removeObjectFrom{class_name}ArrayAtIndex: - Where {class_name} is the name of your class.
        //public void RemoveItem(nint index) {
        //    CallWillChangeInMainArray();
        //    _issuesArrayMainNode.RemoveObject(index);
        //    CallDidChangeInMainArray();
        //}
        //[Export("setIssueItemArray:")] //set{class_name}Array: - Where {class_name} is the name of your class.
        //public void SetArray(NSMutableArray<IssueItem> array) {
        //    CallWillChangeInMainArray();
        //    _issuesArrayMainNode = array;
        //    CallDidChangeInMainArray();
        //}
        //private void CallWillChangeInMainArray() {
        //    WillChangeValue("issueItemArray");
        //}
        //private void CallDidChangeInMainArray() {
        //    DidChangeValue("issueItemArray");
        //}
    }
}
