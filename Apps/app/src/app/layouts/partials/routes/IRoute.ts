import { RouteLocationRaw } from 'vue-router'

export interface IRoute
{
    label: string;
    to: RouteLocationRaw;
}