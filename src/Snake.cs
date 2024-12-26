class Snake {
    public Coord head;
    public LinkedList<Coord> body;

    public Snake(Coord initialPos) {
        this.head = initialPos;
        body = new LinkedList<Coord>();
        body.AddFirst(head);
    }    
    public void grow() {
        body.AddFirst(head);
    }
}