# homex-test-api

This is my solution to HomeX's back-end interview test https://github.com/HomeXLabs/back-end-test

I have provided API endoints so that any client (web/mobile/etc) can retrieve the necessary components to build the tree themselves

**[GET]**

```api/activities```

```api/activities/:id```

```api/activities/:id/children```

```api/activities/:id/people```

```api/people/:id```



Additionally, the following endpoint outputs the tree in JSON format

```api/tree```

Response body: (extract)
```
[
    {
        "id": 1,
        "name": "Develop Software",
        "parentActivityId": null,
        "people": [],
        "children": [
            {
                "id": 3,
                "name": "Architecture",
                "parentActivityId": 1,
                "people": [
                    {
                        "name": "Tifany Mckie"
                    },
                    {
                        "name": "Shannon Linn"
                    },
                    {
                        "name": "Tyrone Kuhns"
                    }
                ],
                "children": [
                    {
                        "id": 6,
                        "name": "Technical Design",
                        "parentActivityId": 3,
                        "people": [
                            {
                                "name": "Shannon Linn"
                            },
                            {
                                "name": "Shannon Linn"
                            }
                        ],
                        "children": []
                    },
                    {
                        "id": 11,
                        "name": "Security Design",
                        "parentActivityId": 3,
                        "people": [
                            {
                                "name": "Tyrone Kuhns"
                            },
                            {
                                "name": "Tifany Mckie"
                            }
                        ],
                        "children": []
                    }
                ]
            },
            {
                "id": 4,
                "name": "Development",
                "parentActivityId": 1,
                "people": [
                    {
                        "name": "Luciano Grosvenor"
                    },
                    {
                        "name": "Sam Hurt"
                    },
                    {
                        "name": "Jorge Silvey"
                    },
                    {
                        "name": "Tyrone Kuhns"
                    },
                    {
                        "name": "Tifany Mckie"
                    }
                ],
                "children": [
                    {
                        "id": 12,
                        "name": "Testing",
                        "parentActivityId": 4,
                        "people": [
                            {
                                "name": "Tyrone Kuhns"
                            },
                            {
                                "name": "Jorge Silvey"
                            },
                            {
                                "name": "Bruce Vannostrand"
                            }
                        ],
                        "children": []
                    },
                    {
                        "id": 14,
                        "name": "Infrastructure",
                        "parentActivityId": 4,
                        "people": [
                            {
                                "name": "Sam Hurt"
                            },
                            {
                                "name": "Jorge Silvey"
                            },
                            {
                                "name": "Bruce Vannostrand"
                            }
                        ],
                        "children": []
                    },
                    {
                        "id": 15,
                        "name": "Coding",
                        "parentActivityId": 4,
                        "people": [
                            {
                                "name": "Luciano Grosvenor"
                            },
                            {
                                "name": "Shannon Linn"
                            },
                            {
                                "name": "Bruce Vannostrand"
                            }
                        ],
                        "children": []
                    }
                ]
            },
            {
                "id": 8,
                "name": "Product Design",
                "parentActivityId": 1,
                "people": [
                    {
                        "name": "Penney Mulvey"
                    },
                    {
                        "name": "Tyrone Kuhns"
                    },
                    {
                        "name": "Danette Caswell"
                    }
                ],
                "children": [
                    {
                        "id": 5,
                        "name": "Business Requirements",
                        "parentActivityId": 8,
                        "people": [
                            {
                                "name": "Tyrone Kuhns"
                            },
                            {
                                "name": "Randolph Varghese"
                            },
                            {
                                "name": "Aline Enlow"
                            }
                        ],
                        "children": [
                            {
                                "id": 2,
                                "name": "Customer Requests",
                                "parentActivityId": 5,
                                "people": [
                                    {
                                        "name": "Randolph Varghese"
                                    },
                                    {
                                        "name": "Emile Foss"
                                    },
                                    {
                                        "name": "Fredda Sledge"
                                    }
                                ],
                                "children": []
                            },
                            {
                                "id": 9,
                                "name": "Legal Rules",
                                "parentActivityId": 5,
                                "people": [
                                    {
                                        "name": "Aline Enlow"
                                    },
                                    {
                                        "name": "Kimberlie Murga"
                                    },
                                    {
                                        "name": "Horacio Smotherman"
                                    }
                                ],
                                "children": []
                            }
                        ]
                    },
                    {
                        "id": 10,
                        "name": "UX Design",
                        "parentActivityId": 8,
                        "people": [
                            {
                                "name": "Danette Caswell"
                            },
                            {
                                "name": "Darell Ringgold"
                            },
                            {
                                "name": "Marielle Blea"
                            }
                        ],
                        "children": [
                            {
                                "id": 7,
                                "name": "User Testing",
                                "parentActivityId": 10,
                                "people": [
                                    {
                                        "name": "Marielle Blea"
                                    },
                                    {
                                        "name": "Deadra Mishler"
                                    },
                                    {
                                        "name": "Valencia Hoke"
                                    }
                                ],
                                "children": []
                            },
                            {
                                "id": 13,
                                "name": "Storyboarding",
                                "parentActivityId": 10,
                                "people": [
                                    {
                                        "name": "Darell Ringgold"
                                    },
                                    {
                                        "name": "Sam Hurt"
                                    },
                                    {
                                        "name": "Jong Hoppe"
                                    }
                                ],
                                "children": []
                            }
                        ]
                    }
                ]
            }
        ]
    }
]
