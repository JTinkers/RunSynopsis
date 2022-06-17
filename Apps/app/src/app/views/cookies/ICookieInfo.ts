import { CookieType } from "./CookieType";

export interface ICookieInfo
{
    name: string;
    type: CookieType;
    purpose: string;
}