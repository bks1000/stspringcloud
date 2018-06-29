package com.june.service;

import com.june.iservice.ISchedualServiceHi;
import org.springframework.stereotype.Component;

@Component
public class SchedualServiceHi implements ISchedualServiceHi {
    @Override
    public String sayHiFromClientOne(String name) {
        return "get error";
    }
}
