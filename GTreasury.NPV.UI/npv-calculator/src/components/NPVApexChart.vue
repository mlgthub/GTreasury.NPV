<template>
    <div>
        <apexchart type="line" height="350" :options="chartOptions" :series="series"></apexchart>
    </div>
</template>

<script setup>
import { defineProps, reactive } from 'vue'
import VueApexCharts from 'vue3-apexcharts'

const props = defineProps({
    chartOptions: {
        type: Object
    },
    series: {
        type: Array
    }
})

console.log(props.chartOptions)
console.log(props.series)

const copiedProps = reactive({ ...props })  

</script>