import { IAuthor, ICategory, ITag } from '..'

export interface IPost
{
    author: IAuthor;
    authorId: string;
    category: ICategory;
    categoryId: string;
    content: string;
    id: string;
    tags: ITag[];
    title: string;
    slug: string;
    updatedAt: string | null;
    writtenAt: string;
}