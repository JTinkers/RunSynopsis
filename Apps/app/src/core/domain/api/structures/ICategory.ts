import { IArticle, IPost } from '..'

export interface ICategory
{
    articles?: IArticle[];
    description: string;
    id: string;
    name: string;
    posts?: IPost[];
}