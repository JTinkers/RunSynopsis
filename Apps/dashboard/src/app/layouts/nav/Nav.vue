<template>
    <div id='nav'>
        <div v-if='user' id='user'>
            <span v-text='user.nickname'/>
            <span id='sign-out' 
                v-text='"Sign-out"' 
                @click='signOut'
            />
        </div>
        <div v-else id='anonymous'>
            <span id='sign-in' 
                v-text='"Sign-in"' 
                @click='signIn'
            />
        </div>
        <SignInDialog v-model:visible='showSignInDialog'/>
    </div>
</template>

<script lang='ts' setup>
    import { computed, ref } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import SignInDialog from './sign-in/SignInDialog.vue'

    const api = useService<IApiService>('IApiService')

    const user = computed(() => api.user)
    const showSignInDialog = ref(false)

    function signIn()
    {
        showSignInDialog.value = true
    }

    async function signOut()
    {
        await api.signOut()
    }
</script>

<style lang='scss' scoped>
    #nav
    {
        display: flex;
        color: white;
        background: black;
        padding: 16px;
    }

    #anonymous
    {
        display: flex;
    }

    #sign-in
    {
        font-size: 10px;
        letter-spacing: 1px;
        text-transform: uppercase;
    }
</style>