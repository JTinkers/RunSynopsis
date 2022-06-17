<template>
    <section id='our-cause-index'>
        <div id='content'>
            <h4 v-text='"Our Cause"'/>
            <p id='message' v-text='message'/>
        </div>
        <span id='revised-at' v-text='revisedAt'/>
    </section>
</template>

<script lang='ts' setup>
    import { computed } from 'vue'
    import { format, formatDistance } from 'date-fns'

    const message = `Gezorb is a website devoted to furthering knowledge in various fields of Computer Science.

        Our objective is to build a repository of articles covering a wide range of subjects in a coherent and laid-back manner with no fluff or fillers.

        We believe complex ideas can be reduced to simple concepts and explained through pragmatic examples and analogies.

        If you find our website useful and support our mission, subscribe to our newsletter!`

    const revisedAt = computed(() =>
    {
        const date = new Date('2022-06-04T11:13')

        const formattedDate = format(date, 'MMMM do, yyyy - h:ma')

        const phrase = formatDistance(date, new Date(), 
        { 
            addSuffix: true
        })

        return `Last revised at ${formattedDate} (${phrase})`
    })
</script>

<style lang='scss' scoped>
    #our-cause-index
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 32px;
        padding: 32px;
    }

    #content
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
    }

    #message
    {
        white-space: pre-line;
    }

    #revised-at
    {
        display: flex;
        color: scale-color($background, $lightness: -40%);
        font-size: 14px;
        font-family: $font-family-primary;
        margin-left: auto;
    }
</style>