<template>
    <DataTable id='messages' 
        :value='messages'
        v-model:expandedRows='expandedRows'
    >
        <Column expander/>
        <Column field='id' 
            header='Id'
            sortable
        />
        <Column field='title' header='Title'/>
        <Column field='mail' header='Mail'/>
        <Column field='submittedAt' 
            header='Sent' 
            sortable
        />
        <Column header='Actions'>
            <template #body='props'>
                <Button label='Remove' @click='remove(props.data.id)'/>
            </template>
        </Column>
        <template #expansion='props'>
            <p v-text='props.data.body'/>
        </template>
    </DataTable>
</template>

<script lang='ts' setup>
    import { ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IApiService, IMessage } from '@/core/domain/api'
    import { getMessagesQuery } from './gql/getMessagesQuery'
    import { removeMessageMutation } from './gql/removeMessageMutation'

    const api = useService<IApiService>('IApiService')
    const expandedRows = ref([])
    const messages = ref<IMessage[]>([])

    async function fetch()
    {
        const response = (await api.query(getMessagesQuery))
            .getMessages

        messages.value.push(...response.messages)
    }

    async function remove(id: string)
    {
        (await api.mutation(removeMessageMutation, { id }))

        messages.value = messages.value.filter(m => m.id !== id)
    }

    onMounted(async () => await fetch())
</script>

<style lang='scss' scoped>
    #messages
    {
        flex-grow: 1;
    }
</style>