import { IAuthor, ICategory, ITag } from '..'

export interface IArticle 
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
    get readTimeMinutes(): string;
}