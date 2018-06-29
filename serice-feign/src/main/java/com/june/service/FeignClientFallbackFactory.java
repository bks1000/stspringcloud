package com.june.service;

import com.june.iservice.ISchedualServiceHi;
import feign.hystrix.FallbackFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
public class FeignClientFallbackFactory implements FallbackFactory<ISchedualServiceHi> {
    private static final Logger LOGGER = LoggerFactory.getLogger(FeignClientFallbackFactory.class);

    @Override
    public ISchedualServiceHi create(Throwable cause) {
        return new ISchedualServiceHi() {
            @Override
            public String sayHiFromClientOne(String name) {
                FeignClientFallbackFactory.LOGGER.info("fallback; reason was:",cause);

                return "error!";
            }
        };
    }
}