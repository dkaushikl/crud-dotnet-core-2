export class Category {
    Id: number;
    Name: string;
    Sequence: number;

    constructor(id: number, name: string, sequence: number) {
        this.Id = id;
        this.Name = name;
        this.Sequence = sequence;
    }
}