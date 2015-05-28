namespace UWT.Web.Interfaces {

    public interface IThumbnail
    {
        int Id { get; set; }

        string Title { get; }

        string Image { get; }
        
        string Description { get; }
    }

}
