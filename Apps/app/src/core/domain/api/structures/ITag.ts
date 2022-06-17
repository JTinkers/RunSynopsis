import { IArticle, IPost } from '..'

export interface ITag
{
    articles?: IArticle[];
    description: string;
    id: string;
    name: string;
    posts?: IPost[];
}