export class Product {

    Id: number;
    CategoryId: number;
    Name: string;
    Description: string;
    Size: string;
    Color: string;

    constructor(id: number, categoryid: number, name: string, description: string, size: string, color: string) {
        this.Id = id;
        this.Name = name;
        this.CategoryId = categoryid;
        this.Description = description;
        this.Size = size;
        this.Color = color;
    }
}
