<template>
    <div class='panel'>
        <slot/>
    </div>
</template>

<style lang='scss' scoped>
    .panel
    {
        border-radius: 3px;
        border: 1px solid scale-color($background, $lightness: -5%);
    }
</style>