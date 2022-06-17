<template>
    <DataTable selection-mode='single' 
        :value='users' 
        show-gridlines
        @row-select='(e: any) => emit(`selected-user`, e.data)'
    >
        <Column field='id' header='Id'/>
        <Column field='nickname' header='Nickname'/>
        <Column field='permissions' header='Permissions'>
            <template #body='props'>
                <div id='permissions'>
                    <span v-for='{ type, value } in props.data.permissions'
                        :key='type + value'
                        v-text='`${type}.${value}`'
                    />
                </div>
            </template>
        </Column>
    </DataTable>
</template>

<script lang='ts' setup>
    import { ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IApiService, IUser } from '@/core/domain/api'
    import { getUsersQuery } from './gql/getUsersQuery'

    const api = useService<IApiService>('IApiService')
    const emit = defineEmits(['selected-user'])
    const users = ref<Array<IUser>>([])

    async function fetch()
    {
        const response = (await api.query(getUsersQuery))
            .getUsers

        users.value.push(...response.users)
    }

    onMounted(async () => await fetch())
</script>

<style lang='scss' scoped>
    :deep(#permissions)
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        font-size: 12px;
        font-weight: 500;
    }
</style>