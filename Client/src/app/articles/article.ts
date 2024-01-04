export class Article {
    id: number;
    active: boolean;
    user: string;
    updatedAt: Date;
    createdAt: Date;
    title: string;
    description: string;
    author: string;
    categoryId: number;

    constructor(){
        this.id = 0;
        this.active = false;
        this.user = '';
        this.updatedAt = new Date();
        this.createdAt = new Date();
        this.title = '';
        this.description = '';
        this.author = '';
        this.categoryId = 0;
    }
}