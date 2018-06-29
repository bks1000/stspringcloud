package com.june.iservice;

import com.june.service.FeignClientFallbackFactory;
import com.june.service.SchedualServiceHi;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

//@FeignClient(value = "service-user",fallback = SchedualServiceHi.class)
@FeignClient(value = "service-user",fallbackFactory = FeignClientFallbackFactory.class)
@Service
public interface ISchedualServiceHi {

    @RequestMapping(value = "/hi",method = RequestMethod.GET)
    String sayHiFromClientOne(@RequestParam(value = "name") String name);
}
