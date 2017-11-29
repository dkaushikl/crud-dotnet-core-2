import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Category } from '../../../core/domain/category'
import { CategoryService } from '../../../core/service/category.service'


@Component({
    selector: 'category',
    templateUrl: '../category/category.component.html',
    providers: [CategoryService],
})

export class CategoryComponent {
    public Category: Category[];

    constructor(private categoryService: CategoryService) {
        console.log("category");
        this.getCategory(); 
    }

    getCategory() {
        this.categoryService.getCategory()
            .subscribe(category => this.Category = category)
    }
}

