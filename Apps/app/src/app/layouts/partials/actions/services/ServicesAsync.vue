<template>
    <div id='service-list'>
        <Service v-for='service in services'
            :key='service.name'
            :service='service'
        />
    </div>
</template>

<script lang='ts' setup>
    import { ref } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import { IServiceHealth } from '@/core/domain/api'
    import { getServicesQuery } from './gql/getServicesQuery'
    import Service from './Service.vue'

    const api = useService<IApiService>('IApiService')
    const services = ref<Array<IServiceHealth>>()

    services.value = await fetch()

    async function fetch()
    {
        const results = (await api.query(getServicesQuery))
            .statuses

        return results
    }
</script>

<style lang='scss' scoped>
    #service-list
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
    }
</style>