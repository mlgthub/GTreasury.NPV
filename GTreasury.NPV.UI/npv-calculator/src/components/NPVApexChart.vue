<template>
    <div>
        <apexchart type="line" height="350" :options="chartOptions" :series="series"></apexchart>
    </div>
</template>

<script setup>
import { defineProps } from 'vue'
import VueApexCharts from 'vue3-apexcharts'

const props = defineProps({
    chartOptions: {
        type: Object
    },
    series: {
        type: Array
    }
})

</script>