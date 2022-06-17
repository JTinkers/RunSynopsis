import { IArticle } from './IArticle'
import { IAuthor } from './IAuthor'
import { ICategory } from './ICategory'
import { ITag } from './ITag'

const avgwpm = 40

export class Article implements IArticle
{
    author: IAuthor;
    authorId: string;
    category: ICategory;
    content: string;
    headerSrc: string;
    id: string;
    synopsis: string;
    tags: ITag[];
    title: string;
    slug: string;
    updatedAt: Date | null;
    writtenAt: Date;

    constructor(article: IArticle)
    {
        this.author = article.author
        this.authorId = article.authorId
        this.category = article.category
        this.content = article.content
        this.headerSrc = article.headerSrc
        this.id = article.id
        this.synopsis = article.synopsis
        this.tags = article.tags
        this.title = article.title
        this.slug = article.slug
        this.updatedAt = article.updatedAt
        this.writtenAt = article.writtenAt
    }

    get readTimeMinutes(): string
    {
        const words = this.content
            .split(' ')
            .length

        return Math.floor(words / avgwpm) + 'm'
    }
}