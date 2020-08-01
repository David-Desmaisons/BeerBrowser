import { shallowMount } from "@vue/test-utils";
import BeerDetail from "@/components/BeerDetail.vue";

describe("BeerDetail.vue", () => {
  it("renders props.msg when passed", () => {
    const wrapper = shallowMount(BeerDetail, {
    });
  });
});
