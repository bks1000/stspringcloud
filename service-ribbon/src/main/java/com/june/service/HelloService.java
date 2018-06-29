package com.june.service;

import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

@Service
public class HelloService {
    @Autowired
    RestTemplate restTemplate;

    @HystrixCommand(fallbackMethod = "hiError")//该注解对该方法创建了熔断器的功能，并指定了fallbackMethod熔断方法
    public String hiService(String name) {
        /**
         * 在浏览器上多次访问http://localhost:8764/hi?name=forezp，浏览器交替显示：

         hi forezp,i am from port:8762
         hi forezp,i am from port:8763
         这说明当我们通过调用restTemplate.getForObject(“http://SERVICE-HI/hi?name=“+name,String.class)方法时，已经做了负载均衡，访问了不同的端口的服务实例。
         */
        return restTemplate.getForObject("http://SERVICE-USER/hi?name="+name,String.class);
    }

    public String hiError(String name){
        return  "hi,"+name+",sorry,error!";
    }
}
