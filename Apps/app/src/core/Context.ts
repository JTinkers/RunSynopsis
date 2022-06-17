import { App } from 'vue';
import { ServiceProvider } from '.'

export abstract class Context
{
    public abstract load(app: App<Element>, serviceProvider: ServiceProvider): App<Element>;
}
