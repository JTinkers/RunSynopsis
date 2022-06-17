import '@/app/assets/scss/main.scss'
import 'primevue/resources/primevue.min.css'
import 'primeicons/primeicons.css'
import 'primevue/resources/themes/saga-blue/theme.css'
import App from '@/app/App.vue'
import PrimeVue from 'primevue/config'
import Button from 'primevue/button'
import Dialog from 'primevue/dialog'
import InputText from 'primevue/inputtext'
import TabView from 'primevue/tabview'
import TabPanel from 'primevue/tabpanel'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import ColumnGroup from 'primevue/columngroup'
import Row from 'primevue/row'
import Panel from 'primevue/panel'
import Textarea from 'primevue/textarea'
import Checkbox from 'primevue/checkbox'
import { createApp } from 'vue'
import { createContextLoader } from '@/core'
import { RouterContext, RouteRecordRaw } from '@/core/domain/router'
import { ApiContext } from '@/core/application/api'
import { PluginContext } from '@/core/domain/plugins'

const routes: Array<RouteRecordRaw> = 
[
    {
        path: '/',
        name: 'dashboard',
        component: () => import('@/app/views/index/Index.vue')
    }
]

const app = createContextLoader(createApp(App))
    .load(new RouterContext(routes))
    .load(new ApiContext())
    .load(new PluginContext())
    .app

app.use(PrimeVue)
    .component('Button', Button)
    .component('Dialog', Dialog)
    .component('TabView', TabView)
    .component('TabPanel', TabPanel)
    .component('InputText', InputText)
    .component('DataTable', DataTable)
    .component('Column', Column)
    .component('ColumnGroup', ColumnGroup)
    .component('Row', Row)
    .component('Panel', Panel)
    .component('Textarea', Textarea)
    .component('Checkbox', Checkbox)
    .mount('#app')