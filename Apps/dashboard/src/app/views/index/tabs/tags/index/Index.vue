<template>
    <DataTable :value='tags'>
        <Column field='id' header='Id'/>
        <Column field='name' 
            header='Name' 
            sortable
        />
        <Column field='description' header='Description'/>
        <Column header='Actions'>
            <template #body='props'>
                <div id='actions'>
                    <Button label='Remove' @click='remove(props.data.id)'/>
                    <Button label='Edit' @click='edit(props.data.id)'/>
                </div>
            </template>
        </Column>
        <EditDialog v-if='selectedTag' 
            :tag='selectedTag' 
            v-model:visible='showEditDialog'
        />
    </DataTable>
</template>

<script lang='ts' setup>
    import EditDialog from './EditDialog.vue'
    import { computed, ref, onMounted } from 'vue'
    import { useService } from '@/core'
    import { IApiService, ITag } from '@/core/domain/api'
    import { getTagsQuery } from './gql/getTagsQuery'
    import { removeTagMutation } from './gql/removeTagMutation'

    const api = useService<IApiService>('IApiService')
    const tags = ref<Array<ITag>>([])
    const selected = ref<string| null>(null)
    const showEditDialog = ref(false)

    const selectedTag = computed(() => tags.value
        .find(tag => tag.id === selected.value))

    async function fetch()
    {
        const response = (await api.query(getTagsQuery))
            .getTags

        tags.value.push(...response.tags)
    }

    async function remove(id: string)
    {
        (await api.mutation(removeTagMutation, { id }))

        tags.value = tags.value.filter(m => m.id !== id)
    }

    async function edit(id: string)
    {
        selected.value = id
        showEditDialog.value = true
    }

    onMounted(async () => await fetch())
</script>

<style lang='scss' scoped>    
    #actions
    {
        display: flex;
        grid-column-gap: 8px;
    }
</style>