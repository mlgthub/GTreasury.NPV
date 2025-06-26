<template>
    <h1>NPV Calculator Dashboard</h1>
    <NPVForm/>
    <button @click="handleClick">Click Me</button>
</template>

<script>
import NPVForm from '../components/NPVForm.vue'

export default{
    name: 'NPVCalculatorDashboard',
    components: { NPVForm },
    setup(){
        
    }
}
</script>

<style>

</style>