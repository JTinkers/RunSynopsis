<template>
    <div v-if='user' id='manage-permissions'>
        <h2 v-text='user.id + ` ` + user.nickname'/>
        <div id='permissions'>
            <div v-for='permission in permissions'
                :key='permission.type'
                class='checkbox'
            >
                <Checkbox
                    :id='`checkbox-${permission.type}.${permission.value}`'
                    :value='permission'
                    v-model='states'
                />
                <label :for='`checkbox-${permission.type}.${permission.value}`' v-text='`${permission.type}.${permission.value}`'/>
            </div>
        </div>
        <Button label='Save' @click='save'/>
    </div>
</template>

<script lang='ts' setup>
    import { PropType, ref, onMounted, watch } from 'vue'
    import { IApiService, IPermission, IUser } from '@/core/domain/api'
    import { useService } from '@/core'
    import { getPermissionsQuery } from './gql/getPermissionsQuery'
    import { grantPermissionMutation } from './gql/grantPermissionMutation'
    import { revokePermissionMutation } from './gql/revokePermissionMutation'

    const api = useService<IApiService>('IApiService')
    const permissions = ref<Array<IPermission>>([])
    const states = ref<Array<IPermission>>([])

    const props = defineProps(
    {
        user:
        {
            type: Object as PropType<IUser | null>,
            required: false
        }
    })

    async function fetch()
    {
        const response = (await api.query(getPermissionsQuery))

        permissions.value.push(...response.permissions)
    }

    async function save()
    {
        if (!props.user)
            return

        const grants = states.value.filter(p => !props.user?.permissions.includes(p))
        const revokes = props.user.permissions.filter(p => !states.value.includes(p))

        grants.forEach(async p => await api.mutation(grantPermissionMutation, 
        { 
            type: p.type,
            value: p.value, 
            userId: props.user?.id 
        }))

        revokes.forEach(async p => await api.mutation(revokePermissionMutation, 
        { 
            type: p.type, 
            value: p.value, 
            userId: props.user?.id 
        }))
    }

    onMounted(async () => await fetch())

    watch(() => props.user, async () =>
    {
        if (props.user)
        {
            states.value = props.user.permissions
        }
    })
</script>

<style lang='scss' scoped>
    #manage-permissions
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 32px;
    }

    #permissions
    {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(400px, 1fr));
        grid-gap: 16px;
    }

    .checkbox
    {
        display: flex;
        align-items: center;
        grid-column-gap: 4px;
    }
</style>