import { CookiePolicyState } from './CookiePolicyState'

export interface ICookiePolicyService
{
    get state(): CookiePolicyState;
    set state(value: CookiePolicyState);
}