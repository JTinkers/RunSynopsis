import { CookiePolicyState, ICookiePolicyService } from '@/core/domain/cookies'
import { CookiePolicyStore } from './CookiePolicyStore'

export class CookiePolicyService implements ICookiePolicyService
{
    private _store!: CookiePolicyStore;

    constructor()
    {
        this._store = new CookiePolicyStore()
    }

    get state(): CookiePolicyState 
    {
        return this._store.state
    }

    set state(value: CookiePolicyState) 
    {
        this._store.state = value
    }
}