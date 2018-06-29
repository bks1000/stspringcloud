package com.june.controller;

import com.june.iservice.ISchedualServiceHi;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.logging.Level;
import java.util.logging.Logger;

@RestController
public class HiController {

    private static final Logger LOG = Logger.getLogger(HiController.class.getName());

    @Autowired
    private ISchedualServiceHi serviceHi;

    @RequestMapping(value = "/hi",method = RequestMethod.GET)
    public String sayHi(@RequestParam String name){
        LOG.log(Level.INFO, "calling trace service-hi  ");
        return serviceHi.sayHiFromClientOne(name);
    }
}
